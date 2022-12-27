import React, {useState} from "react";
import "./YayInput.scss";

export interface YayInputProps {
    type: "text" | "email" | "password";
    readOnly: boolean;
    text?: string;
    placeholder?: string;
    disabled?: boolean;
}

const YayInput: React.FC<YayInputProps> = (props: YayInputProps) => {
    const {type, readOnly, text, placeholder, disabled} = props;

    const [value, setValue] = useState(text);

    const handleValueChange: React.ChangeEventHandler<HTMLInputElement> = (e: React.ChangeEvent<HTMLInputElement>) => {
        setValue(e.target.value);
    };

    return (
        <input type={type} className={"input"} value={value} placeholder={placeholder} disabled={disabled} readOnly={readOnly} onChange={handleValueChange}/>
    );
}

export default YayInput;