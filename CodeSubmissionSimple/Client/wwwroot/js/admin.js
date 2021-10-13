var answerModalId;

function initializeAnswerModalIds()
{
    answerModalId = document.getElementById('answer-modal');
}

function toggle()
{
    if(answerModalId.style.display == 'block')
    {
        answerModalId.style.display = 'none';
    }
    else
    {
        answerModalId.style.display = 'block';
    }    
}