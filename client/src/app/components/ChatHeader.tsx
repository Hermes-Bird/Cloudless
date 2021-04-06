import React from 'react'
import dots from '../../static/icons/chat-header-dots-icon.svg'
import search from '../../static/icons/chat-search-icon.svg'
import Icon from './Icon'

const ChatHeader = () => {
    return (
        <header className="chat-header">
            <img className="avatar chat-header-avatar" src="https://pm1.narvii.com/7635/e33e0e2bf31a2b65079d1c52d511bdbd40286f5fr1-750-967v2_hq.jpg" alt="chat-avatar avatar"/>
            <p className="chat-header-name">Yare Yare Daze</p>
            <p className="chat-header-about">был(а) в сети 32 минут назад</p>
            <img src={search} alt="search" className="chat-header-search"/>
            <img src={dots} alt="dots" className="chat-header-dots"/>
        </header>
    )
}

export default ChatHeader
