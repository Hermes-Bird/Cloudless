import React from 'react'

const Searchbar: React.FC<{onChange: () => void}> = ({onChange}) => {
    return (
        <input className="searchbar" onChange={onChange} type="text"/>
    )
}

export default Searchbar
