let open = document.getElementById("open-edit");
if (open) {
    let close = document.getElementById("e-close-button");
    let topicEditorContainer = document.getElementById("topic-editor-container");

    close.addEventListener("click", function (e) {

        topicEditorContainer.style.display = "none";
    });

    open.addEventListener("click", function (e) {
        topicEditorContainer.style.display = "flex";
    });
}