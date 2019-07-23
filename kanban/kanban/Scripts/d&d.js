var todo = document.querySelector('.todo');

var tds = document.querySelectorAll('.todo');

todo.addEventListener('dragstart', dragStart);
todo.addEventListener('dragend', dragEnd);
todo.addEventListener('dragover', dragOver);
todo.addEventListener('dragenter', dragEnter);
todo.addEventListener('dragleave', dragLeave);
todo.addEventListener('drop', dragDrop);

// Drag Functions
function dragStart() {
    console.log('dragStart');
}

function dragEnd() {
    console.log('dragEnd');
}

function dragOver() {
    console.log('dragOver');
}

function dragEnter() {
    console.log('dragEnter');
}

function dragLeave() {
    console.log('dragLeave');
}

function dragDrop() {
    console.log('dragDrop');
}