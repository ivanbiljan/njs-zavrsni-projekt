import YayLogo from "/src/assets/svgs/yay-logo.svg";
import { isMobileDevice } from "../helpers/helperFunctions";

const HeaderMobile = () => {
    return (
        <></>
    );
};

// TODO: search bar component
const HeaderPc = () => {
    return (
        <header className={"flex flex-row justify-between items-center px-[135px] py-[25px] border-b border-solid border-[rgba(9, 31, 64, 0.08)]"}>
            <YayLogo/>
            <div className={"flex flex-row gap-8"}>
                <p>Categories</p>
                <div>Market ikona</div>
                <div>Hamburger</div>
            </div>
        </header>
    );
};

const Header = () => {
    return isMobileDevice() ? <HeaderMobile /> : <HeaderPc />;
};

export default Header;