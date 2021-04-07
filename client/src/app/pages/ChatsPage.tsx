import React from 'react'
import Header from '../components/Header'
import Searchbar from '../components/Searchbar'
import DialogList from '../components/DialogList'
import ChatHeader from '../components/ChatHeader'
import SendBox from '../components/SendBox'
import MessageContainer from '../components/MessageContainer'

const temp = () => {}

const ChatsPage = () => {
    return (
        <div className="chats-page">
            <Header onIconClick={temp}/>
            <aside className="dialogs-container">
                <Searchbar onChange={temp}/>
                <DialogList/>
            </aside>
            <section className="chat-container">
                <ChatHeader/>
                <MessageContainer/>
                <SendBox/>
            </section>
        </div>
    )
}

export default ChatsPage
