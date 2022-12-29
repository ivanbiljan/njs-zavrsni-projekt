import React from "react";
import CloseButton from "/frontend/src/assets/svgs/close-x-icon.svg";
import "./YayModal.scss";
import YayButton from "../yay-button/YayButton";
import { useDispatch } from "react-redux";
import { hideModal } from "./ReduxSlice";

export interface YayModalProps {
    title: string;
    children: React.ReactNode;
    confirmText?: string;
    onConfirmClick?: () => void;
    cancelText?: string;
    onCancelClick?: () => void;
}

const YayModal = (props: YayModalProps) => {
    const { title, children, confirmText, onConfirmClick, cancelText, onCancelClick } = props;

    const dispatch = useDispatch();

    const handleCloseButtonClick = () => {
        dispatch(hideModal());
    };

    return (
        <div className={"modal-overlay"}>
            <div className={"modal"}>
                <div className={"modal-header"}>
                    <div className={"modal-close-button"} onClick={handleCloseButtonClick}>
                        <CloseButton />
                    </div>
                    <div>
                        {title}
                    </div>
                </div>
                <div className={"modal-body"}>
                    {children}
                </div>
                {(onConfirmClick || onCancelClick) &&
                    <div className={"modal-footer"}>
                        <YayButton onClick={onConfirmClick!} text={confirmText ?? "Confirm"} color={"purple"}/>
                    </div>
                }
            </div>
        </div>
    );
};

export default YayModal;