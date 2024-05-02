$(document).ready(function () {
    _index.Initialization()

})
var _index = {
    Initialization: function () {
        $('.svg-map-clickable').css('fill','white')
        $('.svg-map-clickable').css('stroke','rgb(245, 159, 188)')
        $('.svg-map-clickable').css('stroke-width','1')
        $('.svg-map-clickable').css('outline','none')
        _index.DynamicBind()
    },
    DynamicBind: function () {

        $('body').on('click', '.svg-map-clickable', function (event) {
            $('.svg-map-clickable').css('fill', 'white')
            var element = $(this)
            element.css('fill', '#74993E')
            $('#article-by-location').html('<h2>Bài viết cho tỉnh: ' + element.attr('name') + '</h2>')
        });
    }
}