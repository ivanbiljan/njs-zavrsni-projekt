import { RefObject, useCallback, useLayoutEffect, useRef, useState } from "react";

export const useDimensions = (objectRef: RefObject<any>) => {
    const [width, setWidth] = useState(0);
    const [height, setHeight] = useState(0);

    const observerRef = useRef<ResizeObserver>(new ResizeObserver(entries => {
        for (let entry of entries) {
            setWidth(entry.contentRect.width);
            setHeight(entry.contentRect.height);
        }
    }));

    useLayoutEffect(() => {
            if (objectRef.current) {
                observerRef.current.observe(objectRef.current);

                return () => {
                    observerRef.current.disconnect();
                };
            }
        },
        [objectRef, objectRef.current]);

    return { width, height };
};