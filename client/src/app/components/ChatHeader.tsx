import React from 'react'
import Icon, {Icons} from './Icon'

const ChatHeader = () => {
    return (
        <header className="chat-header">
            <img className="avatar chat-header-avatar" src="https://pm1.narvii.com/7635/e33e0e2bf31a2b65079d1c52d511bdbd40286f5fr1-750-967v2_hq.jpg" alt="chat-avatar avatar"/>
            <p className="chat-header-name">Миша</p>
            <p className="chat-header-about">был(а) в сети 32 минут назад</p>
            <Icon icon={Icons.search} color="#747372" className="chat-header-search"/>
            <Icon icon={Icons.dots} className="chat-header-dots"/>
        </header>
    )
}

export default ChatHeader
