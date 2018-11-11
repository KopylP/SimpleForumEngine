window.onload = function () {
    let mbuttonOpen = document.getElementById("m-button-open");
    'use strict'
    if (mbuttonOpen) {

        let mbuttonClose = document.getElementById("m-close-button");
        let mfoldCreat = document.getElementById("message-creator-container");

        mbuttonClose.addEventListener("click", function (e) {

            mfoldCreat.style.display = "none";
        });

        mbuttonOpen.addEventListener("click", function (e) {
            mfoldCreat.style.display = "flex";
        });
    }
    //
    let buttonOpen = document.getElementById("button-open");
    if (buttonOpen) {
        let buttonClose = document.getElementById("close-button");
        let foldCreat = document.getElementById("folder-creator-container");

        buttonClose.addEventListener("click", function (e) {

            foldCreat.style.display = "none";
        });

        buttonOpen.addEventListener("click", function (e) {
            foldCreat.style.display = "flex";
        });
    }
}