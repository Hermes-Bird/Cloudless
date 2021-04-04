import React, {useState} from 'react'
import logo from '../../static/img/logo.svg'
import RegisterForm from '../forms/RegisterForm'
import LoginForm from '../forms/LoginForm'

const AuthPage = () => {
    const [isRegisterForm, setIsRegisterForm] = useState(true)
    const toggleRegisterForm = () => setIsRegisterForm(!isRegisterForm)

    return (
        <div className="auth-page">
            <div className="auth-page-container">
                <img className="auth-logo" src={logo} alt="logo"/>
                <p className="auth-name">Cloudless</p>
            </div>

            {
                isRegisterForm
                ? <RegisterForm changeForm={toggleRegisterForm}/>
                : <LoginForm changeForm={toggleRegisterForm}/>
            }
        </div>
    )
}

export default AuthPage
