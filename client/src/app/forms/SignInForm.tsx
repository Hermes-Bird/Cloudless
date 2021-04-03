import React from 'react'

const SignInForm = () => {
    return (
        <form className="auth-form">
            <p>Авторизация</p>
            <img src="" alt=""/>
            <input type="text" placeholder="Имя"/>

            <img src="" alt=""/>
            <input type="password" placeholder="Пароль"/>

            <button className="button">Войти</button>
            <a href="#" className="change-auth-link">Регистрация</a>
        </form>
    )
}

export default SignInForm
