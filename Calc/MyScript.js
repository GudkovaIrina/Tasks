var button = document.getElementById('button'),
    fieldOfInput = document.getElementById('expression'),
    result = document.getElementById('result'),
    number = 0;
button.addEventListener("click", calculateExpression);
button.addEventListener("click", outputResult);

function calculateExpression() {
    var expression = fieldOfInput.value,
        nextOperator = "+",
        nextNumber, operator, currentElements,
        re = /(\s*-?[0-9]+(?:\.[0-9]+)?\s*)([+*/\-=])/g;
    do {
        operator = nextOperator;
        currentElements = re.exec(expression);
        nextNumber = currentElements[1];
        switch (operator) {
            case "+": number += +nextNumber; break;
            case "-": number -= +nextNumber; break;
            case "*": number *= +nextNumber; break;
            case "/": number /= +nextNumber; break;
        }
        nextOperator = currentElements[2];
    } while (nextOperator !== "=");
}

function outputResult() {
    var res = document.createTextNode(number.toFixed(2));

    while (result.firstChild) {
        result.removeChild(result.firstChild);
    }

    result.appendChild(res);
}
