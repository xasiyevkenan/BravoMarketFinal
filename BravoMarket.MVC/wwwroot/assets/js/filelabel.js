document.addEventListener("DOMContentLoaded", function () {
  const fileInputs = document.querySelectorAll("input[type='file']");

  fileInputs.forEach(input => {
    input.addEventListener("change", event => {
      const selectedFile = event.target.files[0];
      const label = input.previousElementSibling;
      const pTag = label.querySelector(".show_file");
      if (selectedFile) {
        pTag.textContent = selectedFile.name;
      }
    });
  });
});

const input = document.getElementById("telephone");
const format = "+994";
const placeholders = ["__", "___", "__", "__"];
let currentPlaceholderIndex = 0;

document.addEventListener("DOMContentLoaded", function () {
  const input = document.getElementById("telephone");
  const format = "+994  ";
  const placeholder = "__";

  input.addEventListener("focus", function () {
    input.value = format + placeholder + " " + placeholder + placeholder + " " + placeholder + " " + placeholder;
    input.selectionStart = 5;
    input.selectionEnd = 6;
  });

  input.addEventListener("input", function () {
    const cleanedValue = input.value.replace(/\D/g, "");
    const formattedValue = format + cleanedValue.substring(3, 5) + " " + cleanedValue.substring(5, 8) + " " + cleanedValue.substring(8, 10) + " " + cleanedValue.substring(10, 12);
    input.value = formattedValue;
  });

  input.addEventListener("keydown", function (e) {
    if (e.key === "Backspace") {
      const cursorPos = input.selectionStart;
      if (cursorPos > format.length && cursorPos <= format.length + 12) {
        const cleanedValue = input.value.replace(/\D/g, "");
        const formattedValue = format + cleanedValue.substring(3, 5) + " " + cleanedValue.substring(5, 8) + " " + cleanedValue.substring(8, 10) + " " + cleanedValue.substring(10, 12);
        input.value = formattedValue.substr(0, cursorPos - 1) + formattedValue.substr(cursorPos);
        input.selectionStart = cursorPos - 1;
        input.selectionEnd = cursorPos - 1;
      }
      e.preventDefault();
    }
  });

  input.onblur = function () {
    input.value = null
  }
});