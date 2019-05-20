
/////////////////////////////////////////////////////////////////////////
//                Automatic Dropdown Menu                             //
/////////////////////////////////////////////////////////////////////////
$(function () {
    $('ul.nav li.dropdown').hover(
        function () { $('.dropdown-menu', this).slideDown(); },
        function () { $('.dropdown-menu', this).slideUp('fast'); }
    )
})