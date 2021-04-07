import React from 'react'
import Icon, {Icons} from './Icon'

const SendBox = () => {
    return (
        <div className="chat-sendbox">
            <input type="text" className="inputbox" placeholder="Напишите что-нибудь..."/>
            <Icon icon={Icons.send}/>
        </div>
    )
}

export default SendBox
