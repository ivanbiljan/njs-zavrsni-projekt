import React, { useEffect, useMemo, useRef, useState } from "react";
import { useDimensions } from "./../hooks/useDimensions";
import ForwardButton from "./../../assets/svgs/carousel-forward.svg";
import classNames from "classnames";

export interface YayCarouselProps {
    children: React.ReactNode;
}

export const YayCarousel = (props: YayCarouselProps) => {
    const { children } = props;

    const carouselContainerRef = useRef<HTMLDivElement>(null);
    const { width: carouselWidth } = useDimensions(carouselContainerRef);

    const trackRef = useRef<HTMLDivElement>(null);
    const { width: trackWidth } = useDimensions(trackRef);

    const maxPages = useMemo(() => {
        return Math.floor(trackWidth / (carouselWidth / 2));
    }, [children, trackWidth, carouselWidth]);

    const [activePage, setActivePage] = useState(0);

    const handlePreviousPage = () => {
        trackRef.current!.style.transform = "translateX(" + (activePage - 1) * -(carouselWidth / 2) + "px)";
        setActivePage(activePage - 1);
    };

    const handleNextPage = () => {
        trackRef.current!.style.transform = "translateX(" + (activePage + 1) * -(carouselWidth / 2) + "px)";
        setActivePage(activePage + 1);
    };

    const navigationButtonClasses = classNames("absolute", "top-[50%]", "translate-x-[-50%]", "translate-y-[-50%]", "w-[35px]", "h-[35px]", "border-r-[50%]", "cursor-pointer");

    return (
        <div
            ref={carouselContainerRef}
            className={"w-[95%] lg:w-[1170px] mx-auto my-[50px] relative flex flex-col gap-[1rem] justify-center items-center"}>
            <div className={"w-full overflow-scroll lg:overflow-hidden"}>
                <div ref={trackRef} className={"inline-flex gap-[1rem]"} style={{transition: "transform 0.2s ease-in-out"}}>
                    {children}
                </div>
                <div>
                    <div
                        className={classNames(navigationButtonClasses, activePage === 0 ? "hidden" : "")}
                        onClick={handlePreviousPage}>
                        <ForwardButton />
                    </div>
                    <div
                        className={classNames(navigationButtonClasses, "right-[-30px]", activePage >= maxPages ? "hidden" : "")}
                        onClick={handleNextPage}>
                        <ForwardButton />
                    </div>
                </div>
            </div>
        </div>
    );
};