// Tema escuro - Lógica de alternância e persistência
document.addEventListener('DOMContentLoaded', function() {
    const themeToggleBtn = document.getElementById('themeToggleBtn');
    const themeIcon = themeToggleBtn.querySelector('i');
    
    // Verificar se há uma preferência de tema salva
    const savedTheme = localStorage.getItem('theme');
    
    // Aplicar tema salvo ou usar o padrão (claro)
    if (savedTheme === 'dark') {
        document.body.classList.add('dark-theme');
        themeIcon.classList.remove('fa-moon');
        themeIcon.classList.add('fa-sun');
    }
    
    // Alternar tema ao clicar no botão
    themeToggleBtn.addEventListener('click', function() {
        // Alternar classe no body
        document.body.classList.toggle('dark-theme');
        
        // Alternar ícone
        if (document.body.classList.contains('dark-theme')) {
            themeIcon.classList.remove('fa-moon');
            themeIcon.classList.add('fa-sun');
            localStorage.setItem('theme', 'dark');
        } else {
            themeIcon.classList.remove('fa-sun');
            themeIcon.classList.add('fa-moon');
            localStorage.setItem('theme', 'light');
        }
    });
});
