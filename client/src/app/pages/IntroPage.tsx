import React from 'react'
import logo from '../../static/img/logo.svg'

const IntroPage = () => {
    return (
        <div className="intro-page">
            <div className="intro-page-container">
                <img src={logo} alt="logo" className="intro-page-logo"/>
                <p>Cloudless</p>
            </div>
        </div>
    )
}

export default IntroPage