<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="ITEModel_1.1_" sourceTool="MDE" sourceModelPath="" modelName="IKeyboardInputSinkModel" label="IKeyboardInputSinkModel" sourceBinaryPath="" ruleRuntimeNeedsUpdate="true" replacedInvalidIdentifiers="true" automated="false" referenceID="bbcf70a9-7b9b-4429-b1f3-9454ddcba809" comment="IKeyboardInputSink model" previewMode="false" stateBasedTestGeneration="1" xmlns="http://itebuild.ntdev.corp.microsoft.com/ite/ITEModel_1.1_.xsd">
    <StateVariables referenceID="1a17fafd-0d9d-4a73-8be4-5caaa470a31b" />
    <ModelParameters referenceID="882870de-e07b-431d-8484-37e5196fedca">
        <Parameters referenceID="c586880b-ca40-422a-a1e6-5713ae89041e">
            <Parameter key_Name="ParentType" label="ParentType" key_ActionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" comment="WinForms disabled" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="c7ba4031-9ea6-4909-9742-3e83da1fcc46">
                <ParameterValue key_Name="Avalon" label="Avalon" weight="10" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="857efab8-1807-403a-a79c-1ca26c2e238d" />
                <ParameterValue key_Name="Hwnd" label="Hwnd" weight="10" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="40766223-43eb-4a56-a665-0c2163bea101" />
                <ParameterValue key_Name="WinForms" label="WinForms" weight="1" includeInGenerationType="0" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="7475b6f3-c9e2-4314-ad06-74e09f713406" />
            </Parameter>
            <Parameter key_Name="ChildType" label="ChildType" key_ActionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" comment="WinForms disabled" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9">
                <ParameterValue key_Name="HostedSourcedAvalon" label="HostedSourcedAvalon" weight="10" includeInGenerationType="0" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="31b69d0b-a3c8-4249-89b0-45925b58df1c" />
                <ParameterValue key_Name="SourcedAvalon" label="SourcedAvalon" weight="10" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="c2e3f3ef-d161-440c-91d1-6af727aaa54f" />
                <ParameterValue key_Name="HostedHwnd" label="HostedHwnd" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="c9eafc68-67b3-41a4-9518-daa22b00c014" />
                <ParameterValue key_Name="WinForms" label="WinForms" weight="1" includeInGenerationType="0" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="ec644667-e177-4f67-a2bd-a0951d50a0d4" />
            </Parameter>
            <Parameter key_Name="GrandchildType" label="GrandchildType" key_ActionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" comment="WinForms disabled" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="9f828b8f-fbfc-431b-87e8-9f122f6fce56">
                <ParameterValue key_Name="HostedSourcedAvalon" label="HostedSourcedAvalon" weight="10" includeInGenerationType="0" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="fdcb87c1-ace2-4aae-a61a-a2f9ed11c4db" />
                <ParameterValue key_Name="SourcedAvalon" label="SourcedAvalon" weight="10" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="843506bb-af55-4a81-a456-a9aa03b018e5" />
                <ParameterValue key_Name="HostedHwnd" label="HostedHwnd" weight="10" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="2a1e5d06-d00f-4c64-b611-70ce9ff64370" />
                <ParameterValue key_Name="WinForms" label="WinForms" weight="10" includeInGenerationType="0" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="66ca10a8-ee5e-4028-a450-3df62766b93a" />
                <ParameterValue key_Name="None" label="None" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="3c59e738-2e8d-48ea-bef2-0e019ab0dc4f" />
            </Parameter>
            <Parameter key_Name="MultipleChildren" label="MultipleChildren" key_ActionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" comment="If True each child will have two children of the hosted technology type." dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="ec3017d2-8a59-49a0-b83c-fcea1176a279">
                <ParameterValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="2f0ef748-1b3f-44b2-a4b8-0fc24d7b45ca" />
                <ParameterValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="3917e1a4-a202-411b-ae20-04a49a95ee19" />
            </Parameter>
            <Parameter key_Name="TabExit" label="TabExit" key_ActionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" comment="IF TabEntry==True&#xA;Test tab/shift-tab exiting behavior, parent may take focus or let child retain focus and loop tabstops." dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="f0571816-ddc2-480f-b6f8-9d98710f9083">
                <ParameterValue key_Name="Loop" label="Loop" weight="1" includeInGenerationType="0" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="d2aa7aff-e647-40ee-b6a6-28f2378ccafd" />
                <ParameterValue key_Name="Fallout" label="Fallout" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="4d644edc-7ee0-4c4a-a15a-bf4e0694dacd" />
                <ParameterValue key_Name="DontTab" label="DontTab" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="9813d218-3023-4f44-8b4a-e8dbe9569b6e" />
            </Parameter>
            <Parameter key_Name="HasAccelerators" label="HasAccelerators" key_ActionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="cd6265cf-0698-4381-95d8-a7a0cc47e22d">
                <ParameterValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="d58b599d-f199-4a17-bc38-bc7e0ea64343" />
                <ParameterValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="712663d5-61c7-4ca6-949a-15fec3eab862" />
            </Parameter>
            <Parameter key_Name="HasTabStops" label="HasTabStops" key_ActionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="481b08ef-795c-4f59-acc3-b2c71fb85d50">
                <ParameterValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="68e13612-589b-4c60-a06e-71670cde5991" />
                <ParameterValue key_Name="False" label="False" weight="1" includeInGenerationType="0" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="a672a654-4bd8-41f3-a42a-afcbb09a9ff4" />
            </Parameter>
            <Parameter key_Name="HasMnemonics" label="HasMnemonics" key_ActionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="0378faf9-7588-44d5-b295-b0b616a0e7df">
                <ParameterValue key_Name="True" label="True" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="4288e61f-32f7-4ccd-b20b-7187c6fec433" />
                <ParameterValue key_Name="False" label="False" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f22ebb9e-a0e3-4482-877a-2e13c0d7a212" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="3d58e9f5-57c3-4a6c-8f66-30949b1e71fb">
            <ParameterCluster key_Name="FullCombination" label="FullCombination" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="49fea007-c1b5-49dc-8dff-3bba76918e99">
                <ParameterClusterElement key_ParameterReferenceID="c7ba4031-9ea6-4909-9742-3e83da1fcc46" key_ModelReferenceID="" referenceID="6995a63c-8e4b-4401-82ba-71df92d0ecab" />
                <ParameterClusterElement key_ParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" key_ModelReferenceID="" referenceID="6036b6fa-547f-48e6-9ca3-50d114b265e4" />
                <ParameterClusterElement key_ParameterReferenceID="9f828b8f-fbfc-431b-87e8-9f122f6fce56" key_ModelReferenceID="" referenceID="a7c7cb41-8b7a-4a30-9726-77cc8f634125" />
                <ParameterClusterElement key_ParameterReferenceID="ec3017d2-8a59-49a0-b83c-fcea1176a279" key_ModelReferenceID="" referenceID="cb279ab4-df69-4a36-899e-294a0c95fcdc" />
                <ParameterClusterElement key_ParameterReferenceID="f0571816-ddc2-480f-b6f8-9d98710f9083" key_ModelReferenceID="" referenceID="3e023853-70d1-4829-bcd6-51d865bb24dd" />
                <ParameterClusterElement key_ParameterReferenceID="cd6265cf-0698-4381-95d8-a7a0cc47e22d" key_ModelReferenceID="" referenceID="ac9424db-6929-4444-b75f-0d779f3a1c11" />
                <ParameterClusterElement key_ParameterReferenceID="0378faf9-7588-44d5-b295-b0b616a0e7df" key_ModelReferenceID="" referenceID="e7f8f8df-c8dc-4813-adeb-23a2911ab83f" />
            </ParameterCluster>
            <ParameterDependencyGroup key_Name="ExcludeSameChild" label="ExcludeSameChild" comment="" include="true" referenceID="816af776-a51f-4f83-8eb0-01d872295688">
                <ParameterDependencyElement criteria="0" referenceID="51246673-2b24-4ce7-8531-b810083d37a1">
                    <ParameterDependencyCondition referenceID="0bd3dde8-a268-4c14-9f0d-7980d5c2cfb0">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="c7ba4031-9ea6-4909-9742-3e83da1fcc46" key_ParameterValueReferenceID="40766223-43eb-4a56-a665-0c2163bea101" key_ModelReferenceID="" referenceID="fa8dfa5d-c8d2-41ee-b88f-9bedd0e57dc8" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="15c862bb-93c5-431b-991b-24ca837c9472">
                        <ParameterDependencyTermValue key_ParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" key_ParameterValueReferenceID="31b69d0b-a3c8-4249-89b0-45925b58df1c" key_ModelReferenceID="" referenceID="698bf55a-2cea-463c-86f7-baecbc663f3d" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="3350f98d-7330-4a9e-ac9b-94ab568f4dbf">
                    <ParameterDependencyCondition referenceID="a3efcf56-d0df-4812-a6a9-45ec8e160e34">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" key_ParameterValueReferenceID="c2e3f3ef-d161-440c-91d1-6af727aaa54f" key_ModelReferenceID="" referenceID="a84eeae4-aac3-42d4-98da-fc351de07e83" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="cf010574-6c54-434e-b02a-eb44b7b44ef3">
                        <ParameterDependencyTermValue key_ParameterReferenceID="9f828b8f-fbfc-431b-87e8-9f122f6fce56" key_ParameterValueReferenceID="843506bb-af55-4a81-a456-a9aa03b018e5" key_ModelReferenceID="" referenceID="75c66986-6def-4646-82eb-e25bab0d5443" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="8bfb530e-3dca-4071-913a-8351b0547a69">
                    <ParameterDependencyCondition referenceID="e66580e9-11ce-4c88-b30a-d4c3a8c1c09d">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="c7ba4031-9ea6-4909-9742-3e83da1fcc46" key_ParameterValueReferenceID="40766223-43eb-4a56-a665-0c2163bea101" key_ModelReferenceID="" referenceID="fa8dfa5d-c8d2-41ee-b88f-9bedd0e57dc8" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="b1378796-4ad5-448e-a7c0-71f3e0b3cb4c">
                        <ParameterDependencyTermValue key_ParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" key_ParameterValueReferenceID="c9eafc68-67b3-41a4-9518-daa22b00c014" key_ModelReferenceID="" referenceID="800cd2c3-a6dd-45c4-840e-16a810184f62" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="ce880468-cca5-4381-be07-9e3f73a6775d">
                    <ParameterDependencyCondition referenceID="afaac10e-6c2d-4475-bc35-fa2a1433813d">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="c7ba4031-9ea6-4909-9742-3e83da1fcc46" key_ParameterValueReferenceID="857efab8-1807-403a-a79c-1ca26c2e238d" key_ModelReferenceID="" referenceID="145d4216-5140-40d2-b3ad-6977dcabba2b" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="22f81191-f6df-434e-9edb-70a3ee9210e1">
                        <ParameterDependencyTermValue key_ParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" key_ParameterValueReferenceID="c2e3f3ef-d161-440c-91d1-6af727aaa54f" key_ModelReferenceID="" referenceID="1e106f33-3ccf-4e60-a5de-77d2e5776019" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="5c65bb25-117c-43e7-bb90-1efdf1249dfe">
                    <ParameterDependencyCondition referenceID="97455a0b-0cbb-4bf3-a89b-36d40ae6f99b">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" key_ParameterValueReferenceID="31b69d0b-a3c8-4249-89b0-45925b58df1c" key_ModelReferenceID="" referenceID="6ebc57e4-4f23-4c08-b9bc-fb097cc18190" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="aaac0c2f-0ca5-4da9-930f-bc29d3fc1fb4">
                        <ParameterDependencyTermValue key_ParameterReferenceID="9f828b8f-fbfc-431b-87e8-9f122f6fce56" key_ParameterValueReferenceID="843506bb-af55-4a81-a456-a9aa03b018e5" key_ModelReferenceID="" referenceID="a80302e0-30af-4e03-a907-f850327d1e3c" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="7c37a6fd-15e9-4ce6-8206-3ad229462dc8">
                    <ParameterDependencyCondition referenceID="e70570c1-fca0-4531-a98c-4023dc02c184">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" key_ParameterValueReferenceID="c9eafc68-67b3-41a4-9518-daa22b00c014" key_ModelReferenceID="" referenceID="4bb1ac4b-fcaa-47fe-bc43-74df4de1b181" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="4690c5b5-b3a5-4140-aed1-34dfaa0d0660">
                        <ParameterDependencyTermValue key_ParameterReferenceID="9f828b8f-fbfc-431b-87e8-9f122f6fce56" key_ParameterValueReferenceID="fdcb87c1-ace2-4aae-a61a-a2f9ed11c4db" key_ModelReferenceID="" referenceID="614c9a88-6f51-439d-8069-114a162d83bf" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="22bd8b5b-6983-4868-b2a7-2945d870d052">
                    <ParameterDependencyCondition referenceID="ccab51f5-229c-4c5b-9acc-a65cfc4952d3">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" key_ParameterValueReferenceID="c9eafc68-67b3-41a4-9518-daa22b00c014" key_ModelReferenceID="" referenceID="4bb1ac4b-fcaa-47fe-bc43-74df4de1b181" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="ba4a4550-d1b8-435f-b573-967e57216039">
                        <ParameterDependencyTermValue key_ParameterReferenceID="9f828b8f-fbfc-431b-87e8-9f122f6fce56" key_ParameterValueReferenceID="2a1e5d06-d00f-4c64-b611-70ce9ff64370" key_ModelReferenceID="" referenceID="9a726520-f8d4-4a80-a82f-e49391dfd664" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
            </ParameterDependencyGroup>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="f0ec88b2-96b0-4c9e-a1bb-862247943307">
        <Action key_Name="Run" label="Run" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3">
            <ActionParameters referenceID="2b6a1aec-89cf-45a8-9c6e-07338f4135dd">
                <ActionParameter key_ActionParameterReferenceID="c7ba4031-9ea6-4909-9742-3e83da1fcc46" referenceID="70fd2f63-da94-4b60-9fd7-49ef9d894b99" />
                <ActionParameter key_ActionParameterReferenceID="18aeeffa-0e92-4ac2-9ce4-920489c92fd9" referenceID="014a4420-3ecf-4ea9-b8bf-5d67a61a6cf3" />
                <ActionParameter key_ActionParameterReferenceID="9f828b8f-fbfc-431b-87e8-9f122f6fce56" referenceID="e640f747-537d-446a-9d35-7819cd3e6b1a" />
                <ActionParameter key_ActionParameterReferenceID="ec3017d2-8a59-49a0-b83c-fcea1176a279" referenceID="e8c8b54d-175b-4954-a981-1499722efbf0" />
                <ActionParameter key_ActionParameterReferenceID="f0571816-ddc2-480f-b6f8-9d98710f9083" referenceID="60358a91-5bd3-4719-a9f3-a9e063136c60" />
                <ActionParameter key_ActionParameterReferenceID="cd6265cf-0698-4381-95d8-a7a0cc47e22d" referenceID="d9c752aa-afe6-46d8-98c4-cdf2ad073dd7" />
                <ActionParameter key_ActionParameterReferenceID="481b08ef-795c-4f59-acc3-b2c71fb85d50" referenceID="3e447672-d0d4-45ab-8f93-3536bf342020" />
                <ActionParameter key_ActionParameterReferenceID="0378faf9-7588-44d5-b295-b0b616a0e7df" referenceID="3d0d7cf8-8c00-419d-950d-282a901f8184" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules ruleDLLData="" referenceID="786973d3-5e43-473d-ad12-622ea25925d7" />
    <EntryPoints seed="1" referenceID="35d64bda-1a67-4214-8440-23c73732846a" />
    <AssertionRules referenceID="e5782146-932a-4331-b117-9513d99c8290" />
    <ModelInfo overview="" constructionInfo="" referenceID="7e29f92c-72d0-4327-afde-d4d80396950d" />
    <ModelReferences referenceID="de07304a-65a6-4d57-95ef-09080c6ee1fc" />
    <ModelLinkRules referenceID="f2f0256c-b16d-442f-bf50-7c9fa15b179b" />
    <TestQueries referenceID="0ff6cedc-ffc9-43d4-91df-5d1dfda0fa56">
        <TestQuery key_Name="Pairwise pattern" label="Pairwise pattern" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;E:\src\testsrc\windowstestdata\redist\client\wcptests\core\bvt\Interop\IKeyboardInputSinkModel.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;E:\src\testsrc\windowstestdata\redist\client\wcptests\core\bvt\Interop\KeyboardInteropModel_Pairwise.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="8447abee-152c-48bf-ae90-d0eb476527be" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="6e407d99-2d79-471e-aa5e-fca2599c5ef2">
                <TestPatternElement testPatternElementType="0" modelReferenceID="bbcf70a9-7b9b-4429-b1f3-9454ddcba809" referenceID="f9e1ad84-0999-4bc4-bd25-333c6addc0a7">
                    <ActionTestPatternElement actionReferenceID="ccd3bed6-b5d7-466c-aa29-d8e77a7802a3" referenceID="b734f186-14ac-4002-b032-8c826d68a515" />
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="71bb749a-8a03-4a28-9530-4ce5179a2a68" />
    <CustomData referenceID="4ab25c91-f72c-4d81-a1c6-f57bca937b21" />
</IteModel>