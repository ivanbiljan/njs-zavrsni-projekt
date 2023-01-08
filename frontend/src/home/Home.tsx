import { YayCard } from "./../shared/yay-card/YayCard";
import Loader from "/src/assets/svgs/yay-logo.svg";
import { YayCarousel } from "./../shared/yay-carousel/YayCarousel";
import Header from "../layout/Header";
import Footer from "../layout/Footer";
import { useCategories } from "./../shared/api/categories/CategoriesApi";

export const Route = "/";

export const Home = () => {
    const categories = useCategories();

    console.log(categories);

    return (
        <>
            <Header/>
            <Footer/>
        </>
    );
};