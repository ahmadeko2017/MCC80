const btnCol1 = document.getElementById("btnColor");
const p1 = document.querySelector("div.container div.row div");
const p2 = document.querySelector("div.container div.row div.row div");

btnCol1.addEventListener("click", () => {
    p1.classList.toggle("text-white")
    p1.classList.toggle("bg-dark")
    btnCol1.classList.toggle("btn-active")
})

const btnCol2 = document.getElementById("btnText");
btnCol2.addEventListener("click", () => {
    p1.innerText = "Edited by button";
    p1.style.color = "black";
    p1.style.backgroundColor = "white";
})

const btnCol3 = document.getElementById("btnGanti");
btnCol3.addEventListener("click", () => {
    p2.style.color = "green";
    p2.style.backgroundColor = "yellow";
})
