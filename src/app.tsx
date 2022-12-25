import YayButton from "./components/button/button";
import LoaderIcon from "./assets/svgs/loader";

const App = () => {
    return (
        <div className={"app"}>
            <YayButton icon={<LoaderIcon width={16} height={16} color={"white"}/>} text={"Title"} color={"purple"} onClick={() => console.log("click")} disabled={false} loading={false} />
        </div>
    );
};

export default App;