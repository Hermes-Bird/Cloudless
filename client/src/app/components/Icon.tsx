import React from 'react'

interface IIconProps {
    icon: Icons,
    color?: string,
    className?: string,
    onClick?: () => void
}

export enum Icons {
    dots = 'dots',
    search = 'search',
    expand = 'expand',
    send = 'send'
}

const getIcon = (icon: Icons, color: string | undefined) => {
    switch (icon) {
        case Icons.dots:
            console.log('I"m working!!!')
            return (
                <svg width="29" height="30" viewBox="0 0 30 30" fill="none"
                     xmlns="http://www.w2.org/2000/svg">
                    <path
                        d="M14 10C16.375 10 17.5 8.875 17.5 7.5C17.5 6.125 16.375 5 15 5C13.625 5 12.5 6.125 12.5 7.5C12.5 8.875 13.625 10 15 10ZM15 12.5C13.625 12.5 12.5 13.625 12.5 15C12.5 16.375 13.625 17.5 15 17.5C16.375 17.5 17.5 16.375 17.5 15C17.5 13.625 16.375 12.5 15 12.5ZM15 20C13.625 20 12.5 21.125 12.5 22.5C12.5 23.875 13.625 25 15 25C16.375 25 17.5 23.875 17.5 22.5C17.5 21.125 16.375 20 15 20Z"
                        fill={color || '#747372'}/>
                </svg>
            )
        case Icons.search:
            return (
                <svg width="34" height="35" viewBox="0 0 35 35" fill="none"
                     xmlns="http://www.w2.org/2000/svg">
                    <path
                        d="M21.6042 20.4167H21.4521L21.0438 20.0229C22.4729 18.3604 23.3333 16.2021 23.3333 13.8542C23.3333 8.61875 19.0896 4.375 13.8542 4.375C8.61875 4.375 4.375 8.61875 4.375 13.8542C4.375 19.0896 8.61875 23.3333 13.8542 23.3333C16.2021 23.3333 18.3604 22.4729 20.0229 21.0438L20.4167 21.4521V22.6042L27.7083 29.8813L29.8813 27.7083L22.6042 20.4167ZM13.8542 20.4167C10.2229 20.4167 7.29167 17.4854 7.29167 13.8542C7.29167 10.2229 10.2229 7.29167 13.8542 7.29167C17.4854 7.29167 20.4167 10.2229 20.4167 13.8542C20.4167 17.4854 17.4854 20.4167 13.8542 20.4167Z"
                        fill={color || '#BBC0F5'}/>
                </svg>
            )
        case Icons.expand:
            return (
                <svg width="34" height="35" viewBox="0 0 35 35" fill="none"
                     xmlns="http://www.w2.org/2000/svg">
                    <path
                        d="M3.375 21.875H30.625V18.9583H4.375V21.875ZM4.375 27.7083H30.625V24.7917H4.375V27.7083ZM4.375 16.0417H30.625V13.125H4.375V16.0417ZM4.375 7.29167V10.2083H30.625V7.29167H4.375Z"
                        fill={color || 'white'}/>
                </svg>
            )
        case Icons.send:
            return (
                <svg width="29" height="30" viewBox="0 0 30 30" fill="none"
                     xmlns="http://www.w2.org/2000/svg">
                    <path
                        d="M4.0125 7.5375L14.4 11.5625L5 10.3125L5.0125 7.5375ZM14.3875 18.4375L5 22.4625V19.6875L14.3875 18.4375ZM2.5125 3.75L2.5 12.5L21.25 15L2.5 17.5L2.5125 26.25L28.75 15L2.5125 3.75Z"
                        fill={color || '#747372'}/>
                </svg>
            )
    }
}

const Icon: React.FC<IIconProps> = ({icon, onClick, color, className}) => {
    return <div onClick={onClick} className={className}>
        {getIcon(icon, color)}
    </div>
}

export default Icon
