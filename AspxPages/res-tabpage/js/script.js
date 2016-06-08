var tab_click = function (e)
{
    $('.container .tabbody>div').hide();
    $('.nav-tabs>li').removeClass('active');
    $('.container .tabbody .' + $(this).attr('id')).show();
    $(this).addClass('active');
}
function add_tab(tabid, tabname)
{
    var content = "A fractal is generally \"a rough or fragmented geometric shape that can be subdivided into parts, each of which is (at least approximately) a reduced-size copy of the whole,\" a property called self-similarity. The term was coined by BenoA! Mandelbrot in 1975 and was derived from the Latin fractus meaning \"broken\" or \fractured.\" A fractal often has the following features: Because they appear similar...";
    var image = "/Images/fractal.jpg";
    var htmlStr = "<div style='overflow:hidden'>" +
                        "<image class='imgtag' src='" + image + "'/>" +
                        "<span class='description'>" + content + "</span>" +
                  "</div>" +
                  "<div class='property-header'>" + "Factz from Wikipedia: we found the following about fractal" + "</div>" +
                  "<div class='property odd'>" +
                        "<span class='row-header'>fractal</span>" +
                        "<span class='col1'>includes :</span>" +
                        "<span class='col2'>type, components, ranges, coastlines, flakes</span>" +
                  "</div>" +
                  "<div class='property'>" +
                        "<span class='row-header'></span>" +
                        "<span class='col1'>transforms :</span>" +
                        "<span class='col2'>compression, fractals, process, technology</span>" +
                  "</div>" +
                  "<div class='property odd'>" +
                        "<span class='row-header'></span>" +
                        "<span class='col1'>sequences :</span>" +
                        "<span class='col2'>a.b., AABAB and BBBBBBBAAAAAA</span>" +
                  "</div>";
    url = "#";
    $('.nav-tabs>li').unbind('click');
    $('.nav-tabs').html($('.nav-tabs').html() + "<li id="+tabid+"><a href=\""+url+"\">" + tabname + "</a></li>");
    $('.nav-tabs>li').on('click', tab_click);
    $('.container .tabbody').html($('.container .tabbody').html() + "<div style='display:none;' class='" + tabid + "'>" + htmlStr + "</div>");
}

$(function () {
    add_tab("palmberg-tree", "palmberg-tree");
    add_tab("highcharts", "highcharts");
    add_tab("mbostock1", "mbostock1");
    add_tab("mbostock2", "mbostock2");
    $('#palmberg-tree').click();
});
