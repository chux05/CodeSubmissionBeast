var number;
var description;

function getIds()
{
    number = document.getElementById("question-title");
    description = document.getElementById("question-description");
}


function getValues()
{
    console.log(number.innerText, description.innerText)
    return [number.innerText, description.innerText];
}


