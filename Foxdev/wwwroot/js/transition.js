document.addEventListener('DOMContentLoaded', function() {
   
    const guestLink = document.querySelector('a[asp-action="Convidado"]');

    if (guestLink) {
        guestLink.addEventListener('click', function(event) {
            event.preventDefault(); 
            const targetUrl = this.href;

            
            document.body.classList.add('fade-out');

           
            setTimeout(function() {
                window.location.href = targetUrl;
            }, 500); 
        });
    }

    
    if (!document.body.classList.contains('fade-out')) {
    
       setTimeout(() => {
          document.body.style.opacity = '1'; 
       }, 50); 
    }
});

