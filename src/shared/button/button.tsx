import React from "react";
import classNames from "classnames";
import "./button.scss"
import LoaderDefault from "/src/assets/images/loader.png";
import LoaderWhite from "/src/assets/images/loader-white.png";

export interface ButtonProps {
    onClick: () => void;
    text: string;
    color: "purple" | "white";
    icon?: JSX.Element;
    htmlType?: "button" | "submit";
    size?: "large" | undefined;
    className?: string;
    disabled?: boolean;
    loading?: boolean;
}

const YayButton: React.FC<ButtonProps> = (props: ButtonProps) => {
    const { onClick, icon, text, color, htmlType, size, className, disabled, loading } = props;
    const onClickHandler = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        if (disabled || loading) {
            e.preventDefault();

            return;
        }

        onClick();
    };

    const classes = classNames("btn", color,  size ? `size--${size}` : "", className);

    if (loading) {
        const Loader = color === "purple" ? LoaderWhite : LoaderDefault;

        return <button className={classNames(classes, "loading")}>
            <img src={Loader} alt={"Loader"} className={"rotate"}/>
        </button>;
    }

    return (
        <button type={htmlType ?? "button"} className={classes} disabled={disabled} onClick={onClickHandler}>
            {icon &&
                <div>
                    {icon}
                </div>
            }
            <div className={"btn-text"}>{text}</div>
        </button>
    );
};

export default YayButton;
