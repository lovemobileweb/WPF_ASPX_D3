var iMbostockIndex = 0;
var iIntervalSecond = 1;
var arrMbostockData = [];
var hAnimateTimer;

function myfunc_initdata() {
    arrMbostockData = [];
}

function myfunc_setdata(arrData) {
    arrMbostockData = arrData;
}

function myfunc_adddata(error, data) {
    arrMbostockData[arrMbostockData.length] = data;
}

function myfunc_mbostock_animate(intervalSecond) {
    iIntervalSecond = intervalSecond;
    iMbostockIndex = 0;
    hAnimateTimer = setTimeout(myfunc_onAnimatedMbostock, iIntervalSecond * 1000);
}

function myfunc_onAnimatedMbostock() {
    if (arrMbostockData.length > 0)
        myfunc_mbostock(null, arrMbostockData[iMbostockIndex++ % arrMbostockData.length]);
    setTimeout(myfunc_onAnimatedMbostock, iIntervalSecond * 1000);
}

function myfunc_mbostock(error, classes) {
    if (error) throw error;

    if ($("svg").length > 0)
        d3.select("svg").remove();

    var diameter = 960,
        radius = diameter / 2,
        innerRadius = radius - 120;

    var cluster = d3.layout.cluster()
        .size([360, innerRadius])
        .sort(null)
        .value(function (d) { return d.size; });

    var bundle = d3.layout.bundle();

    var line = d3.svg.line.radial()
        .interpolate("bundle")
        .tension(.85)
        .radius(function (d) { return d.y; })
        .angle(function (d) { return d.x / 180 * Math.PI; });

    var svg = d3.select("body").append("svg")
        .attr("width", diameter)
        .attr("height", diameter)
      .append("g")
        .attr("transform", "translate(" + radius + "," + radius + ")");

    var nodes = cluster.nodes(packageHierarchy(classes)),
        links = packageImports(nodes);

    svg.selectAll(".link")
        .data(bundle(links))
      .enter().append("path")
        .attr("class", "link")
        .attr("d", line);

    svg.selectAll(".node")
        .data(nodes.filter(function (n) { return !n.children; }))
      .enter().append("g")
        .attr("class", "node")
        .attr("transform", function (d) { return "rotate(" + (d.x - 90) + ")translate(" + d.y + ")"; })
      .append("text")
        .attr("dx", function (d) { return d.x < 180 ? 8 : -8; })
        .attr("dy", ".31em")
        .attr("text-anchor", function (d) { return d.x < 180 ? "start" : "end"; })
        .attr("transform", function (d) { return d.x < 180 ? null : "rotate(180)"; })
        .text(function (d) { return d.key; });

    d3.select(self.frameElement).style("height", diameter + "px");
}

// load data array //
myfunc_initdata();
d3.json("/res-mbostock1/json/data1.json", myfunc_adddata);
d3.json("/res-mbostock1/json/data2.json", myfunc_adddata);
d3.json("/res-mbostock1/json/data3.json", myfunc_adddata);
/////////////////////

// display data //
setTimeout(myfunc_mbostock_animate(1), 2000);
//////////////////

// Lazily construct the package hierarchy from class names.
function packageHierarchy(classes) {
    var map = {};

    function find(name, data) {
        var node = map[name], i;
        if (!node) {
            node = map[name] = data || { name: name, children: [] };
            if (name.length) {
                node.parent = find(name.substring(0, i = name.lastIndexOf(".")));
                node.parent.children.push(node);
                node.key = name.substring(i + 1);
            }
        }
        return node;
    }

    classes.forEach(function (d) {
        find(d.name, d);
    });

    return map[""];
}

// Return a list of imports for the given array of nodes.
function packageImports(nodes) {
    var map = {},
        imports = [];

    // Compute a map from name to node.
    nodes.forEach(function (d) {
        map[d.name] = d;
    });

    // For each import, construct a link from the source to target node.
    nodes.forEach(function (d) {
        if (d.imports) d.imports.forEach(function (i) {
            imports.push({ source: map[d.name], target: map[i] });
        });
    });

    return imports;
}