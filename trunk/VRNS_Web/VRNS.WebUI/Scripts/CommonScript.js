$(document).ready(function () {

    bindTooltip();

});

function bindTooltip() {
    $("div.tile-content").tooltip({
        position: {
            my: "left+8 bottom+20",
            at: "center top",
            within: ".content-wrapper"
        }
    });
}




function PreventKeyIn(controlId) {
    $("#" + controlId).keydown(function (e) {
        if (e.keyCode == 46 || e.keyCode == 8) {
            //Delete and backspace clear text 
            $(this).val(''); //Clear text
        }
        e.preventDefault();
    });
}
