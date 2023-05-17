import React, { useState } from 'react';

type ModalProps = {
    isOpen: boolean;
    onClose: () => void;
    children: React.ReactNode;
};

const Modal = (props: ModalProps) => {
    const handleClose = () => {
        props.onClose();
    };

    return (
        <>
            {props.isOpen && (
                <div className="modal-overlay" onClick={handleClose}>
                    <div className="modal-content" onClick={(e) => e.stopPropagation()}>
                        <button className="modal-close" onClick={handleClose}>
                            X
                        </button>
                        {props.children}
                    </div>
                </div>
            )}
        </>
    );
};

export default Modal;