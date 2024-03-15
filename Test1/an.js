scenarioSummary.strategies.forEach((scenario) => {
    if (scenario.strategy === 'desktop') {
        this.scenarioSummaries[
            i
        ].warningMetrics.isMeasurementSubjectDesktop = true;
    }
    if (scenario.strategy === 'mobile') {
        this.scenarioSummaries[
            i
        ].warningMetrics.isMeasurementSubjectMobile = true;
    }
    if (scenario.pageTransitions !== undefined && scenario.pageTransitions.length !== 0) {
        // すべての測定値の中から、問題あり・やや問題ありの値だけを端末・バイタル値ごとに配列にする
        scenario.pageTransitions.forEach((pageTransition) => {
            // 問題あり
            this.addBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.badPage,
                scenario.strategy,
                'LCP',
                (measurement_st !== null ? measurement_st.LCP_BORDER_BAD : WebVitalsConst.LCP_BORDER_BAD),
            );
            this.addBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.badPage,
                scenario.strategy,
                'FCP',
                (measurement_st !== null ? measurement_st.FCP_BORDER_BAD : WebVitalsConst.FCP_BORDER_BAD),
            );
            this.addBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.badPage,
                scenario.strategy,
                'TTFB',
                (measurement_st !== null ? measurement_st.TTFB_BORDER_BAD : WebVitalsConst.TTFB_BORDER_BAD),
            );
            this.addBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.badPage,
                scenario.strategy,
                'SI',
                (measurement_st !== null ? http ://measurement_st.SI_BORDER_BAD : http://WebVitalsConst.SI_BORDER_BAD),
                  );
            this.addBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.badPage,
                scenario.strategy,
                'TBT',
                (measurement_st !== null ? measurement_st.TBT_BORDER_BAD : WebVitalsConst.TBT_BORDER_BAD),
            );
            this.addBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.badPage,
                scenario.strategy,
                'CLS',
                (measurement_st !== null ? measurement_st.CLS_BORDER_BAD : WebVitalsConst.CLS_BORDER_BAD),
            );
            // やや問題あり
            this.addNoGoodAndNoBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage,
                scenario.strategy,
                'LCP',
                (measurement_st !== null ? measurement_st.LCP_BORDER_BAD : WebVitalsConst.LCP_BORDER_BAD),
                (measurement_st !== null ? measurement_st.LCP_BORDER_GOOD : WebVitalsConst.LCP_BORDER_GOOD),
            );
            this.addNoGoodAndNoBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage,
                scenario.strategy,
                'FCP',
                (measurement_st !== null ? measurement_st.FCP_BORDER_BAD : WebVitalsConst.FCP_BORDER_BAD),
                (measurement_st !== null ? measurement_st.FCP_BORDER_GOOD : WebVitalsConst.FCP_BORDER_GOOD),
            );
            this.addNoGoodAndNoBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage,
                scenario.strategy,
                'TTFB',
                (measurement_st !== null ? measurement_st.TTFB_BORDER_BAD : WebVitalsConst.TTFB_BORDER_BAD),
                (measurement_st !== null ? measurement_st.TTFB_BORDER_GOOD : WebVitalsConst.TTFB_BORDER_GOOD),
            );
            this.addNoGoodAndNoBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage,
                scenario.strategy,
                'SI',
                (measurement_st !== null ? http ://measurement_st.SI_BORDER_BAD : http://WebVitalsConst.SI_BORDER_BAD),
                    (measurement_st !== null ? http ://measurement_st.SI_BORDER_GOOD : http://WebVitalsConst.SI_BORDER_GOOD),
                  );
            this.addNoGoodAndNoBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage,
                scenario.strategy,
                'TBT',
                (measurement_st !== null ? measurement_st.TBT_BORDER_BAD : WebVitalsConst.TBT_BORDER_BAD),
                (measurement_st !== null ? measurement_st.TBT_BORDER_GOOD : WebVitalsConst.TBT_BORDER_GOOD),
            );
            this.addNoGoodAndNoBadPageByVitalArray(
                pageTransition.metrics,
                this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage,
                scenario.strategy,
                'CLS',
                (measurement_st !== null ? measurement_st.CLS_BORDER_BAD : WebVitalsConst.CLS_BORDER_BAD),
                (measurement_st !== null ? measurement_st.CLS_BORDER_GOOD : WebVitalsConst.CLS_BORDER_GOOD),
            );
        });
    }

    // 問題あり・やや問題ありの件数を取得（計測結果列の表示絵文字とポップアップの制御用）
    const badPageValues =
        this.scenarioSummaries[i].warningMetrics.badPage
            [scenario.strategy]['CLS']
        .concat(
            this.scenarioSummaries[i].warningMetrics.badPage[
            scenario.strategy
            ]['LCP'],
        )
        .concat(
            this.scenarioSummaries[i].warningMetrics.badPage[
            scenario.strategy
            ]['FCP'],
        )
        .concat(
            this.scenarioSummaries[i].warningMetrics.badPage[
            scenario.strategy
            ]['TTFB'],
        )
        .concat(
            this.scenarioSummaries[i].warningMetrics.badPage[
            scenario.strategy
            ]['SI'],
        )
        .concat(
            this.scenarioSummaries[i].warningMetrics.badPage[
            scenario.strategy
            ]['TBT'],
        );
    this.scenarioSummaries[i].warningMetrics.badPageCounter[
        scenario.strategy
    ] = badPageValues.length;
    const noGoodAndNoBadPageValues = this.scenarioSummaries[
        i
    ].warningMetrics.noGoodAndNoBadPage[scenario.strategy]['CLS']
        .concat(
            this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage[
            scenario.strategy
            ]['LCP'],
        )
        .concat(
            this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage[
            scenario.strategy
            ]['FCP'],
        )
        .concat(
            this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage[
            scenario.strategy
            ]['TTFB'],
        )
        .concat(
            this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage[
            scenario.strategy
            ]['SI'],
        )
        .concat(
            this.scenarioSummaries[i].warningMetrics.noGoodAndNoBadPage[
            scenario.strategy
            ]['TBT'],
        );
    this.scenarioSummaries[
        i
    ].warningMetrics.noGoodAndNoBadPageCounter[scenario.strategy] =
        noGoodAndNoBadPageValues.length;
});
measurement_st.si_border_bad