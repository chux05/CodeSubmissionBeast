var imageModalId;

function initialize()
{
    imageModalId = document.getElementById('image-modal');
    imageModalId.style.display = 'none';
    console.log(imageModalId);
    console.log("variables initialized")
}

function showModal()
{
    if(imageModalId.style.display === 'block')
    {
        imageModalId.style.display = 'none';
    }
    else
    {
        imageModalId.style.display = 'block';
    }
}


