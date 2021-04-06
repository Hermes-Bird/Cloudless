import React from 'react'

interface IIconProps {
    alt?: string,
    icon: string,
    onClick?: () => void
}

const Icon: React.FC<IIconProps> = ({icon, onClick, alt}) => <img src={icon} style={{fill: 'black'}} alt={alt} onClick={onClick}/>

export default Icon
