import React from 'react'


const Dialog : React.FC<{dialog: any, active?: boolean}> = ({dialog, active}) => {
    return (
        <div className={`dialog ${active ? 'active' : ''}`}>
            <img className="avatar dialog-avatar" src={dialog.avatar} alt=""/>
            <h4 className="dialog-title">{dialog.title}</h4>
            <p className="dialog-message">{dialog.message}</p>
        </div>
    )
}

const dialog = {
    avatar: 'https://pm1.narvii.com/7635/e33e0e2bf31a2b65079d1c52d511bdbd40286f5fr1-750-967v2_hq.jpg',
    title: 'Title',
    message: 'Test message for dialog, very very long'
}

const DialogList = () => {
    return (
        <div className="dialog-list">
            <Dialog dialog={dialog}/>
            <Dialog dialog={dialog} active/>
            <Dialog dialog={dialog}/>
            <Dialog dialog={dialog}/>
            <Dialog dialog={dialog}/>
            <Dialog dialog={dialog}/>
            <Dialog dialog={dialog}/>
            <Dialog dialog={dialog}/>
            <Dialog dialog={dialog}/>
        </div>
    )
}

export default DialogList
