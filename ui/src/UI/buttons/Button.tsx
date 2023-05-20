import React from 'react';

type ButtonProps = {
    onClick: () => void;
    label: string;
    customClass: string | null;
};

const Button = (props: ButtonProps) => {
    return (
        <button className={`generic-button ${props.customClass ? props.customClass : ''}`}  onClick = { props.onClick } >
            {props.label}
        </button>
    );
};

export default Button;