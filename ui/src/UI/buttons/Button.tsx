import React from 'react';

type ButtonProps = {
    onClick: () => void;
    label: string;
};

const Button = (props: ButtonProps) => {
    return (
        <button className="generic-button" onClick={props.onClick}>
            {props.label}
        </button>
    );
};

export default Button;