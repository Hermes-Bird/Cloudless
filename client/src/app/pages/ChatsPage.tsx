import React from 'react'
import Header from '../components/Header'
import Searchbar from '../components/Searchbar'
import DialogList from '../components/DialogList'

const temp = () => {}

const ChatsPage = () => {
    return (
        <div className="chats-page">
            <Header onIconClick={temp}/>
            <aside className="dialogs-container">
                <Searchbar onChange={temp}/>
                <DialogList/>
            </aside>
        </div>
    )
}

export default ChatsPage
