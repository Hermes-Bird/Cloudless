import React from 'react'
import Header from '../components/Header'
import Searchbar from '../components/Searchbar'
import DialogList from '../components/DialogList'
import ChatHeader from '../components/ChatHeader'

const temp = () => {}

const ChatsPage = () => {
    return (
        <div className="chats-page">
            <Header onIconClick={temp}/>
            <aside className="dialogs-container">
                <Searchbar onChange={temp}/>
                <DialogList/>
            </aside>
            <ChatHeader/>
        </div>
    )
}

export default ChatsPage
