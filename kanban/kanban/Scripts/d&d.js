var dragelements = document.querySelectorAll('.dragelement');
for (var dragelement of dragelements) {
    dragelement.addEventListener('dragstart', dragStart);
    dragelement.addEventListener('dragend', dragEnd);
}

var dropelements = document.querySelectorAll('.dropelement');
for (var dropelement of dropelements) {
    dropelement.addEventListener('dragover', dragOver);
    dropelement.addEventListener('dragenter', dragEnter);
    dropelement.addEventListener('dragleave', dragLeave);
    dropelement.addEventListener('drop', dragDrop);
}

// Drag functions
function dragStart() {
    console.log('dragStart');
}
function dragEnd() {
    console.log('dragEnd');
}
// Drop functions
function dragOver(e) {
    e.preventDefault();
    console.log('dragOver');
}
function dragEnter(e) {
    e.preventDefault();
    console.log('dragEnter');
}
function dragLeave() {
    console.log('dragLeave');
}
function dragDrop() {
    console.log('dragDrop');
}