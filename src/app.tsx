import YayButton from "./components/button/button";

const App = () => {
    return (
        <div className={"app"}>
            <YayButton text={"Title"} styleType={"primary"} onClick={() => console.log("click")} disabled={false} />
        </div>
    );
};

export default App;