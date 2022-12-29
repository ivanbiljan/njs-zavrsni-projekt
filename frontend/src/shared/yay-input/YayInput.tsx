import React, { useState } from "react";
import EyeOpenIcon from "./../../assets/svgs/eye-open.svg";
import EyeClosedIcon from "./../../assets/svgs/eye-closed.svg";
import ErrorIcon from "./../../assets/svgs/error-label-icon.svg";
import "./YayInput.scss";
import classNames from "classnames";

export interface YayInputProps {
    type: "text" | "email" | "password";
    readOnly: boolean;
    name?: string;
    label?: string;
    text?: string;
    error?: string;
    placeholder?: string;
    disabled?: boolean;
}

const YayInput: React.FC<YayInputProps> = React.forwardRef((props: YayInputProps, ref: any) => {
    const { type, name, readOnly, label, text, error, placeholder, disabled, ...rest } = props;

    const [inputType, setInputType] = useState(type);
    const [value, setValue] = useState(text || "");

    const handleValueChange: React.ChangeEventHandler<HTMLInputElement> = (e: React.ChangeEvent<HTMLInputElement>) => {
        e.preventDefault();
        setValue(e.target.value);
    };

    const togglePasswordType = () => {
        setInputType(inputType === "password" ? "text" : "password");
    };

    const labelClasses = classNames("label", error ? "error" : "");
    const inputClasses = classNames("input", error ? "error" : "");

    // @ts-ignore
    return (
        <div className={"wrapper"}>
            <label className={labelClasses}>
                {error && (
                    <span><ErrorIcon/></span>
                )}
                {label}
            </label>
            <div className={inputClasses}>
                <input ref={ref} name={name} type={inputType} value={value} placeholder={placeholder} disabled={disabled} readOnly={readOnly} {...rest} onChange={handleValueChange} />
                {type === "password" && (
                    <span className={"icon-right"} onClick={togglePasswordType}>
                        {inputType === "password" ? <EyeOpenIcon /> : <EyeClosedIcon />}
                    </span>
                )}
            </div>
            {error && (
                <small className={"feedback"}>{error}</small>
            )}
        </div>
    );
});

export default YayInput;