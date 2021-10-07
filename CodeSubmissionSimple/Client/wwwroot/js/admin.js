var emails;
var useremail = ""

function initailizeEmails()
{
    emails = document.querySelectorAll('#email');

    divs = []
    for(var i = 0; i < emails.length; i++)
    {
        divs.push(emails[i])
    }
    
    divs.forEach((item,index) => {
        item.addEventListener('click', function(){
            console.log(item.innerText + "*")
            useremail = item.innerText;                      
        });
    });
  
}

function getEmail()
{   
    console.log(useremail + "%")
    return useremail;
}

