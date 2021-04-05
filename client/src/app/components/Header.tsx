import React from 'react'
import expandIcon from '../../static/icons/expand-icon.svg'

const Header: React.FC<{onIconClick: () => void}> = ({onIconClick}) => {
    return (
        <header className="header">
            <img onClick={onIconClick} src={expandIcon} alt="expand-icon"/>
            <strong className="name">Cloudless</strong>
        </header>
    )
}

export default Header
