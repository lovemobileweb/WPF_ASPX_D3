var tab_click = function (e)
{
    $('.nav-tabs>li').removeClass('active');
    $(this).addClass('active');
}
function add_tab(tabname, url)
{
    url = "#";
    $('.nav-tabs>li').unbind('click');
    $('.nav-tabs').html($('.nav-tabs').html() + "<li><a href=\""+url+"\">" + tabname + "</a></li>");
    $('.nav-tabs>li').on('click', tab_click);
}

$(function () {
    add_tab("palmberg-tree", "/palmberg-tree/palmberg-tree.html");
    add_tab("highcharts", "/highcharts/highcharts.html");
    add_tab("mbostock1", "/mbostock/mbostock1.html");
    add_tab("mbostock2", "/mbostock2/mbostock2.html");
});
