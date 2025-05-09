// transition.js
document.addEventListener('DOMContentLoaded', function() {
    // Find the 'Entrar como Convidado' link/button
    // Assuming the link has the asp-action="Convidado"
    const guestLink = document.querySelector('a[asp-action="Convidado"]');

    if (guestLink) {
        guestLink.addEventListener('click', function(event) {
            event.preventDefault(); // Prevent immediate navigation
            const targetUrl = this.href;

            // Add fade-out class to body
            document.body.classList.add('fade-out');

            // Wait for the transition to complete before navigating
            setTimeout(function() {
                window.location.href = targetUrl;
            }, 500); // Match the duration in transitions.css (0.5s)
        });
    }

    // Apply fade-in effect on page load (optional, can be added to specific pages or layout)
    // Ensure the body doesn't start with fade-out if navigating back/forward
    if (!document.body.classList.contains('fade-out')) {
       // Add a slight delay to ensure the CSS is loaded and transition applies correctly
       setTimeout(() => {
          document.body.style.opacity = '1'; // Ensure opacity is set if it wasn't initially
          // Or apply a fade-in class if defined
          // document.body.classList.add('fade-in');
       }, 50); // Small delay
    }
});

