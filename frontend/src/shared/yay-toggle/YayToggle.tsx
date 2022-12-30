import "./YayToggle.scss";

export const YayToggle = () => {
    return (
        <div className={"switch"}>
            <input type={"checkbox"} checked={true} />
            <span className={"slider round"}></span>
        </div>
    );
};