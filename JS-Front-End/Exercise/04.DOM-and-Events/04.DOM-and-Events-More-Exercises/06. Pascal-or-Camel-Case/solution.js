function solve() {
  const allInputs = Array.from(document.getElementsByTagName("input"));
  const transformButton = allInputs[2];

  const result = document.getElementById("result");

  const inputTextToConvert = document.getElementById("text");
  const pattern = /[^a-zA-Z0-9]+(.)/g;
  const textToConvert = inputTextToConvert.value.toLowerCase();
  const namingInput = document.getElementById("naming-convention");
  let namingText = namingInput.value;

  if (namingText === "Camel Case") {
    result.textContent = textToConvert.replace(pattern, (m, chr) =>
      chr.toUpperCase()
    );
  } else if (namingText === "Pascal Case") {
    let newTextToConvert = " " + textToConvert;
    result.textContent = newTextToConvert.replace(pattern, (m, chr) =>
      chr.toUpperCase()
    );
  } else {
    result.textContent = "Error!";
  }
}
