var tab_click = function (e)
{
    $('.container .tabbody *').hide();
    $('.nav-tabs>li').removeClass('active');
    $('.container .tabbody .' + $(this).attr('id')).show();
    $(this).addClass('active');
}
function add_tab(tabid, tabname, content)
{
    url = "#";
    $('.nav-tabs>li').unbind('click');
    $('.nav-tabs').html($('.nav-tabs').html() + "<li id="+tabid+"><a href=\""+url+"\">" + tabname + "</a></li>");
    $('.nav-tabs>li').on('click', tab_click);
    $('.container .tabbody').html($('.container .tabbody').html() + "<div style='display:none;' class='" + tabid + "'>" + content + "</div>");
}

$(function () {
    add_tab("palmberg-tree", "palmberg-tree", "content palmberg-tree");
    add_tab("highcharts", "highcharts", "content highcharts");
    add_tab("mbostock1", "mbostock1", "content mbostock1");
    add_tab("mbostock2", "mbostock2", "content mbostock2");
    $('#palmberg-tree').click();
});
