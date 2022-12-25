import React from "react";
import classNames from "classnames";
import "./button.scss"

export interface ButtonProps {
    onClick: () => void;
    text: string;
    styleType: "primary" | "secondary";
    htmlType?: "button" | "submit";
    size?: "large" | undefined;
    className?: string;
    disabled?: boolean;
    loading?: boolean;
}

const YayButton: React.FC<ButtonProps> = (props: ButtonProps) => {
    const { onClick, text, styleType, htmlType, size, className, disabled, loading } = props;
    const onClickHandler = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        if (disabled) {
            e.preventDefault();

            return;
        }

        onClick();
    };

    const classes = classNames("btn", styleType,  size ? `size--${size}` : "", className);

    if (loading) {
        return <button className={classes}></button>;
    }

    return (
        <button type={htmlType ?? "button"} className={classes} disabled={disabled} onClick={onClickHandler}>
            <div className={"btn-text"}>{text}</div>
        </button>
    );
};

export default YayButton;
