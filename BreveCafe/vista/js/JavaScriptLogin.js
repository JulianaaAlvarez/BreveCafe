function showSignIn() {
    document.getElementById("loginForm").style.display = "block"; // Mostrar el formulario de inicio de sesión
    document.getElementById("signUpForm").style.display = "none"; // Ocultar el formulario de registro
    document.getElementById("signInTab").classList.add("active"); // Agregar clase activa al tab de Sign In
    document.getElementById("signUpTab").classList.remove("active"); // Remover clase activa del tab de Sign Up
}

function showSignUp() {
    document.getElementById("loginForm").style.display = "none"; // Ocultar el formulario de inicio de sesión
    document.getElementById("signUpForm").style.display = "block"; // Mostrar el formulario de registro
    document.getElementById("signInTab").classList.remove("active"); // Remover clase activa del tab de Sign In
    document.getElementById("signUpTab").classList.add("active"); // Agregar clase activa al tab de Sign Up
}
