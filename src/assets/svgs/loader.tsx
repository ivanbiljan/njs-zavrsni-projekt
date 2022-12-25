import React from "react";
import {IconProps} from "../icon";

const LoaderIcon = (props: IconProps) => {
    return (
        <svg width={props.width} height={props.height} viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path fillRule="evenodd" clipRule="evenodd"
                  d="M12 24C18.6274 24 24 18.6274 24 12C24 5.37258 18.6274 0 12 0C5.37258 0 0 5.37258 0 12C0 18.6274 5.37258 24 12 24ZM12 22C17.5228 22 22 17.5228 22 12C22 6.47715 17.5228 2 12 2C6.47715 2 2 6.47715 2 12C2 17.5228 6.47715 22 12 22Z"
                  fill="url(#paint0_angular_6455_2229)"/>
            <path fillRule="evenodd" clipRule="evenodd"
                  d="M22.7813 9.60074C23.3291 9.53007 23.8304 9.91682 23.9011 10.4646C23.9668 10.9738 23.9997 11.4866 23.9997 12C23.9997 12.5523 23.552 13 22.9997 13C22.4474 13 21.9997 12.5523 21.9997 12C21.9997 11.5722 21.9723 11.1448 21.9175 10.7205C21.8468 10.1727 22.2336 9.67141 22.7813 9.60074Z"
                  fill="#613EEA"/>
            <defs>
                <radialGradient id="paint0_angular_6455_2229" cx="0" cy="0" r="1" gradientUnits="userSpaceOnUse"
                                gradientTransform="translate(12 12) scale(12)">
                    <stop stopColor="#ffffff" stopOpacity="0"/>
                    <stop offset="0.0001" stopColor="#ffffff" stopOpacity="0"/>
                    <stop offset="1" stopColor="#ffffff"/>
                </radialGradient>
            </defs>
        </svg>
    );
};

export default LoaderIcon;
