import React from 'react'

const MyComponent = () => {
    return (
        <form className="auth-form">
            <p>Регистрация</p>
            <img src="" alt=""/>
            <input type="text" placeholder="Username"/>

            <img src="" alt=""/>
            <input type="text" placeholder="Почта"/>

            <img src="" alt=""/>
            <input type="text" placeholder="Пароль"/>

            <img src="" alt=""/>
            <input type="text" placeholder="Повторить пароль"/>

            <button className="button">Зарегистрироваться</button>
            <a href="#" className="form-change-link">Уже есть аккаунт?</a>
        </form>
    )
}

export default MyComponent
