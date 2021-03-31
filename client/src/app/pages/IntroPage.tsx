import React from 'react';
import logo from '../../static/img/logo.svg'

const IntroPage = () => {
    return (
        <div className="intro-page">
            <div className="intro-page-container">
                <img src={logo} alt="logo" className="intro-page-logo"/>
                Cloudless
            </div>
        </div>
    )    
};

export default IntroPage;