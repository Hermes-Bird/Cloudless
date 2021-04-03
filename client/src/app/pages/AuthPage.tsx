import React from 'react'
import logo from '../../static/img/logo.svg'
import SignInForm from '../forms/SignInForm'

const AuthPage = () => {
    return (
        <div className="auth-page">
            <div className="auth-page-container">
                <img className="auth-logo" src={logo} alt="logo"/>
                <p className="auth-name">Cloudless</p>
            </div>
           <SignInForm/>
        </div>
    )
}

export default AuthPage